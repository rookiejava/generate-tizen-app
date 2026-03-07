param(
    [Parameter(Mandatory=$true, HelpMessage="다운로드 받은 패키지들을 저장할 경로를 입력하세요. 예: C:\workspace\temp\Tizen_Dlls")]
    [string]$DestinationPath,
    
    [Parameter(Mandatory=$false)]
    [string]$PackageListPath = "$PSScriptRoot\TizenPackageList.txt"
)

# 1. 대상 폴더가 없으면 생성합니다.
if (-not (Test-Path $DestinationPath)) {
    Write-Host "폴더가 존재하지 않아 새로 생성합니다: $DestinationPath" -ForegroundColor Yellow
    New-Item -ItemType Directory -Force -Path $DestinationPath | Out-Null
}

# 2. 패키지 다운로드를 위해 Tizen 프레임워크 호환성 검사를 무시하는 가장 확실한 방법인 nuget.exe를 사용합니다.
$nugetExe = Join-Path $DestinationPath "nuget.exe"
if (-not (Test-Path $nugetExe)) {
    Write-Host "nuget.exe를 다운로드합니다..." -ForegroundColor Cyan
    Invoke-WebRequest -Uri "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe" -OutFile $nugetExe
}

# 3. 텍스트 파일에서 패키지 목록을 가져옵니다. 빈 줄이나 주석 처리는 건너뜁니다.
$packages = Get-Content $PackageListPath | Where-Object { $_.Trim() -ne "" -and (-not $_.StartsWith("#")) }

foreach ($item in $packages) {
    # 사용자가 URL 형태로 입력했을 경우 패키지 이름만 파싱 (예: https://www.nuget.org/packages/Tizen.UI)
    if ($item -match "nuget\.org/packages/([^/]+)") {
        $packageId = $matches[1]
    } else {
        $packageId = $item.Trim()
    }
    
    Write-Host "`n[$packageId] 패키지 다운로드 및 추출 시작..." -ForegroundColor Green
    
    # nuget.exe install 명령어는 .nupkg를 다운받고 자동으로 압축까지 풀어주는 꿀 명령어입니다.
    # -Prerelease 옵션을 넣어 시험판(rc 등) 최신 버전까지 가져오게 합니다.
    & $nugetExe install $packageId -OutputDirectory $DestinationPath -Prerelease -NonInteractive -DependencyVersion Ignore
}

Write-Host "`n모든 패키지 다운로드 및 추출 완료! 🚀" -ForegroundColor Yellow
Write-Host "추출된 파일들은 [$DestinationPath] 에서 확인할 수 있습니다." -ForegroundColor Yellow
