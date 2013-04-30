function Get-MSBuildProject {
    param(
        [parameter(ValueFromPipelineByPropertyName = $true)]
        [string[]]$ProjectName
    )
    Process {
        (Resolve-ProjectName $ProjectName) | % {
            $path = $_.FullName
            @([Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($path))[0]
        }
    }
}

function Resolve-ProjectName {
    param(
        [parameter(ValueFromPipelineByPropertyName = $true)]
        [string[]]$ProjectName
    )
    
    if($ProjectName) {
        $projects = Get-Project $ProjectName
    }
    else {
        # All projects by default
        $projects = Get-Project
    }
    
    $projects
}




$project = Get-Project
$buildProject = Get-MSBuildProject

$target = $buildProject.Xml.AddTarget("WeldAfterbuild")
$target.AfterTargets = "AfterBuild"
$task = $target.AddTask("Exec")
$task.SetParameter("Command", "`".\..\packages\Weld.1.0.0\tools\Weld.console`" bin\`$(TargetFileName) `"`$(ProjectDir)\Scripts\Weld`"")


$project.Save() #persists the changes


