pipeline {
    agent any

    stages {
        stage('Build') {
            steps {
                echo 'Building..'
				sh 'dotnet build'
            }
        }
        stage('Test') {
            steps {
                echo 'Testing..'
				sh 'dotnet test'
            }
        }
		
		stage('Deploy') {
			steps {   
				echo 'Deploying ...'
				sh 'dotnet publish KinoServerBackend/KinoServerBackend.csproj -c Release -r linux-x64 --self-contained'
			}
		}
    }
}
