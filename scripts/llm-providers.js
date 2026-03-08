/**
 * llm-providers.js
 * 
 * 멀티 LLM 프로바이더 추상화 레이어
 * 지원: Gemini (기본), OpenAI, Claude (Anthropic)
 * 
 * 사용법:
 *   const { createProvider } = require('./llm-providers');
 *   const llm = createProvider('gemini'); // or 'openai', 'claude'
 *   const code = await llm.generateCode(systemPrompt, userPrompt);
 */

// ─── Gemini Provider ───
class GeminiProvider {
    constructor() {
        this.apiKey = process.env.GEMINI_API_KEY;
        if (!this.apiKey) throw new Error('GEMINI_API_KEY 환경변수가 설정되지 않았습니다.');
        this.model = process.env.GEMINI_MODEL || 'gemini-2.5-flash';
        this.baseUrl = 'https://generativelanguage.googleapis.com/v1beta';
    }

    async generateCode(systemPrompt, userPrompt) {
        const url = `${this.baseUrl}/models/${this.model}:generateContent?key=${this.apiKey}`;
        const body = {
            system_instruction: { parts: [{ text: systemPrompt }] },
            contents: [{ role: 'user', parts: [{ text: userPrompt }] }],
            generationConfig: {
                temperature: 0.2,
                maxOutputTokens: 8192,
            },
        };

        const res = await fetch(url, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(body),
        });

        if (!res.ok) {
            const err = await res.text();
            throw new Error(`Gemini API error (${res.status}): ${err}`);
        }

        const data = await res.json();
        const text = data.candidates?.[0]?.content?.parts?.[0]?.text;
        if (!text) throw new Error('Gemini 응답에서 텍스트를 찾을 수 없습니다.');
        return text;
    }
}

// ─── OpenAI Provider ───
class OpenAIProvider {
    constructor() {
        this.apiKey = process.env.OPENAI_API_KEY;
        if (!this.apiKey) throw new Error('OPENAI_API_KEY 환경변수가 설정되지 않았습니다.');
        this.model = process.env.OPENAI_MODEL || 'gpt-4o';
        this.baseUrl = process.env.OPENAI_BASE_URL || 'https://api.openai.com/v1';
    }

    async generateCode(systemPrompt, userPrompt) {
        const url = `${this.baseUrl}/chat/completions`;
        const body = {
            model: this.model,
            messages: [
                { role: 'system', content: systemPrompt },
                { role: 'user', content: userPrompt },
            ],
            temperature: 0.2,
            max_tokens: 8192,
        };

        const res = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${this.apiKey}`,
            },
            body: JSON.stringify(body),
        });

        if (!res.ok) {
            const err = await res.text();
            throw new Error(`OpenAI API error (${res.status}): ${err}`);
        }

        const data = await res.json();
        const text = data.choices?.[0]?.message?.content;
        if (!text) throw new Error('OpenAI 응답에서 텍스트를 찾을 수 없습니다.');
        return text;
    }
}

// ─── Claude (Anthropic) Provider ───
class ClaudeProvider {
    constructor() {
        this.apiKey = process.env.ANTHROPIC_API_KEY;
        if (!this.apiKey) throw new Error('ANTHROPIC_API_KEY 환경변수가 설정되지 않았습니다.');
        this.model = process.env.ANTHROPIC_MODEL || 'claude-sonnet-4-20250514';
        this.baseUrl = 'https://api.anthropic.com/v1';
    }

    async generateCode(systemPrompt, userPrompt) {
        const url = `${this.baseUrl}/messages`;
        const body = {
            model: this.model,
            system: systemPrompt,
            messages: [
                { role: 'user', content: userPrompt },
            ],
            temperature: 0.2,
            max_tokens: 8192,
        };

        const res = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'x-api-key': this.apiKey,
                'anthropic-version': '2023-06-01',
            },
            body: JSON.stringify(body),
        });

        if (!res.ok) {
            const err = await res.text();
            throw new Error(`Claude API error (${res.status}): ${err}`);
        }

        const data = await res.json();
        const text = data.content?.[0]?.text;
        if (!text) throw new Error('Claude 응답에서 텍스트를 찾을 수 없습니다.');
        return text;
    }
}

// ─── Factory ───
const providers = {
    gemini: GeminiProvider,
    openai: OpenAIProvider,
    claude: ClaudeProvider,
};

function createProvider(name = 'gemini') {
    const Provider = providers[name.toLowerCase()];
    if (!Provider) {
        throw new Error(`지원하지 않는 프로바이더: "${name}". 사용 가능: ${Object.keys(providers).join(', ')}`);
    }
    return new Provider();
}

module.exports = { createProvider, providers: Object.keys(providers) };
