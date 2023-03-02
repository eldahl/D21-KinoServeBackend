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
                echo 'Deploying....'
		sh 'dotnet publish KinoServerBackend/KinoServerBackend.csproj -c Release -r linux-x64 --self-contained'
		ftpPublisher alwaysPublishFromMaster: true, continueOnError: true, failOnError: false, masterNodeName: 'master', paramPublish: [parameterName: ''], publishers: [
			[configName: 'Backend deploy', ftpRetry: [ retries: 2, retryDelay: 1000], transfers: [
				[asciiMode: false, cleanRemote: true, excludes: '', flatten: false, makeEmptyDirs: true, noDefaultExcludes: true, patternSeparator: '[, ]+', remoteDirectory: '~/API', remoteDirectorySDF: false, removePrefix: 'KinoServeBackend/KinoServerBackend/bin/Release/net6.0/linux-x64/publish/', sourceFiles: 'KinoServeBackend/KinoServerBackend/bin/Release/net6.0/linux-x64/publish/**']
			], usePromotionTimestamp: false, useWorkspaceInPromotion: false, verbose: true]
		]
            }
        }
    }
}
