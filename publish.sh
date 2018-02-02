if [ ! -z "$TRAVIS_TAG" ] ; then 
	docker tag $DOCKER_HUB_ORG/brisk-controller:latest-dev $DOCKER_HUB_ORG/brisk-controller:$TRAVIS_TAG
	docker tag $DOCKER_HUB_ORG/brisk-queue:latest-dev $DOCKER_HUB_ORG/brisk-queue:$TRAVIS_TAG
	docker tag $DOCKER_HUB_ORG/brisk-gateway:latest-dev $DOCKER_HUB_ORG/brisk-gateway:$TRAVIS_TAG

	echo $DOCKER_HUB_PASSWORD | docker login -u=$DOCKER_HUB_USERNAME --password-stdin
	docker push $DOCKER_HUB_ORG/brisk-controller:$TRAVIS_TAG
	docker push $DOCKER_HUB_ORG/brisk-gateway:$TRAVIS_TAG
	docker push $DOCKER_HUB_ORG/brisk-queue:$TRAVIS_TAG
	docker logout
fi