#!/bin/bash
# =============================================================================
# Download-TizenPackages.sh
# Linux/macOS용 Tizen UI 패키지 다운로드 스크립트
# 사용법: ./Download-TizenPackages.sh <다운로드_경로> [패키지_목록_파일]
# =============================================================================

set -e

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
DESTINATION="${1:?다운로드 받을 경로를 입력하세요. 예: ./Packages}"
PACKAGE_LIST="${2:-$SCRIPT_DIR/TizenPackageList.txt}"

NUGET_API="https://api.nuget.org/v3-flatcontainer"

# 색상 출력
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
CYAN='\033[0;36m'
RED='\033[0;31m'
NC='\033[0m'

# 1. 대상 폴더 생성
if [ ! -d "$DESTINATION" ]; then
    echo -e "${YELLOW}폴더가 존재하지 않아 새로 생성합니다: $DESTINATION${NC}"
    mkdir -p "$DESTINATION"
fi

# 2. 패키지 목록 파일 확인
if [ ! -f "$PACKAGE_LIST" ]; then
    echo -e "${RED}패키지 목록 파일을 찾을 수 없습니다: $PACKAGE_LIST${NC}"
    exit 1
fi

# 3. 패키지 다운로드
while IFS= read -r line || [ -n "$line" ]; do
    # 빈 줄, 주석(#) 건너뛰기
    trimmed=$(echo "$line" | xargs)
    [[ -z "$trimmed" || "$trimmed" == \#* ]] && continue

    # URL 형태인 경우 패키지 이름만 추출
    if [[ "$trimmed" =~ nuget\.org/packages/([^/]+) ]]; then
        PACKAGE_ID="${BASH_REMATCH[1]}"
    else
        PACKAGE_ID="$trimmed"
    fi

    # 소문자로 변환 (NuGet flat container API는 소문자만 허용)
    PACKAGE_ID_LOWER=$(echo "$PACKAGE_ID" | tr '[:upper:]' '[:lower:]')

    echo -e "\n${GREEN}[$PACKAGE_ID] 패키지 처리 중...${NC}"

    # NuGet API에서 사용 가능한 버전 목록 가져오기
    echo -e "${CYAN}  버전 목록 조회 중...${NC}"
    VERSIONS_JSON=$(curl -sS "$NUGET_API/$PACKAGE_ID_LOWER/index.json")
    
    if [ $? -ne 0 ] || echo "$VERSIONS_JSON" | grep -q "BlobNotFound"; then
        echo -e "${RED}  패키지를 찾을 수 없습니다: $PACKAGE_ID${NC}"
        continue
    fi

    # 최신 버전(마지막 항목) 가져오기
    LATEST_VERSION=$(echo "$VERSIONS_JSON" | grep -oP '"[0-9][^"]*"' | tail -1 | tr -d '"')
    
    if [ -z "$LATEST_VERSION" ]; then
        echo -e "${RED}  버전을 찾을 수 없습니다: $PACKAGE_ID${NC}"
        continue
    fi

    echo -e "${CYAN}  최신 버전: $LATEST_VERSION${NC}"

    # 이미 다운로드된 경우 건너뛰기
    PACKAGE_DIR="$DESTINATION/$PACKAGE_ID.$LATEST_VERSION"
    if [ -d "$PACKAGE_DIR" ]; then
        echo -e "${YELLOW}  이미 존재합니다. 건너뜁니다.${NC}"
        continue
    fi

    # .nupkg 다운로드
    NUPKG_URL="$NUGET_API/$PACKAGE_ID_LOWER/$LATEST_VERSION/$PACKAGE_ID_LOWER.$LATEST_VERSION.nupkg"
    NUPKG_FILE="$DESTINATION/$PACKAGE_ID_LOWER.$LATEST_VERSION.nupkg"
    
    echo -e "${CYAN}  다운로드 중: $NUPKG_URL${NC}"
    curl -sS -L -o "$NUPKG_FILE" "$NUPKG_URL"

    # 압축 해제 (.nupkg는 zip 형식)
    echo -e "${CYAN}  압축 해제 중...${NC}"
    mkdir -p "$PACKAGE_DIR"
    unzip -qo "$NUPKG_FILE" -d "$PACKAGE_DIR"
    
    # .nupkg 원본도 폴더 안에 보관
    mv "$NUPKG_FILE" "$PACKAGE_DIR/"

    echo -e "${GREEN}  ✅ 완료!${NC}"

done < "$PACKAGE_LIST"

echo -e "\n${YELLOW}모든 패키지 다운로드 및 추출 완료! 🚀${NC}"
echo -e "${YELLOW}추출된 파일들은 [$DESTINATION] 에서 확인할 수 있습니다.${NC}"
