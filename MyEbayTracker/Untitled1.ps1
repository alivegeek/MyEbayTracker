function Collect-CsText {
    param (
        [Parameter(Mandatory=$true)]
        [string]$OutputFile
    )

    $currentDirectory = $PSScriptRoot
    $csFiles = Get-ChildItem -Path $currentDirectory -Recurse -Filter "*.cs"
    $collectedText = ""

    foreach ($file in $csFiles) {
        $collectedText += Get-Content -Path $file.FullName -Raw
    }

    Set-Content -Path $OutputFile -Value $collectedText
}

# Usage example
$outputFilePath = "collected_text.txt"
Collect-CsText -OutputFile $outputFilePath