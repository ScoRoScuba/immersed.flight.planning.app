node {
    stage 'Clean workspace'
        cleanWs()

	stage 'Checkout'
		checkout scm
	
    stage 'Build & publish'        
        def builtImage = docker.build("zooplamatch:${env.BUILD_ID}")
        //builtImage.push()

	stage 'Archive'
		archive 'ProjectName/bin/Release/**'

}