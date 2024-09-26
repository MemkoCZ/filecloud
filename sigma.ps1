# Function to display the menu
function Show-Menu {
    Clear-Host
    Write-Host "=== Main Menu ==="
    Write-Host "1: Be Sigma"
    Write-Host "2: Quit Life"
    Write-Host "3: Restart App"
    Write-Host "4: Exit"
}

# Function to handle user choice
function Handle-Choice {
    param (
        [int]$choice
    )

    switch ($choice) {
        1 {
            Start-Process "https://www.youtube.com/watch?v=dQw4w9WgXcQ"
        }
        2 {
            Start-Process "https://www.youtube.com/watch?v=DnxG7Qdghj0"
        }
        3 {
            Restart-Computer -Force
        }
        4 {
            exit
        }
        default {
            Write-Host "Invalid choice, please try again."
        }
    }
}

# Main loop
do {
    Show-Menu
    $userChoice = Read-Host "Please enter your choice (1-4)"
    Handle-Choice $userChoice
    Start-Sleep -Seconds 2
} while ($true)
