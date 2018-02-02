if [ ! -s "$TRAVIS_TAG" ] ; then 
	docker tag $DOCKER_HUB_ORG/brisk-controller:latest-dev $DOCKER_HUB_ORG/brisk-controller:$TRAVIS_TAG;
	docker login -u=$DOCKER_HUB_USERNAME -p=$DOCKER_HUB_PASSWORD;
	docker push $DOCKER_HUB_ORG/brisk-controller:$TRAVIS_TAG;

	docker tag $DOCKER_HUB_ORG/brisk-gateway:latest-dev $DOCKER_HUB_ORG/brisk-gateway:$TRAVIS_TAG;
	docker login -u=$DOCKER_HUB_USERNAME -p=$DOCKER_HUB_PASSWORD;
	docker push $DOCKER_HUB_ORG/brisk-gateway:$TRAVIS_TAG;

	docker tag $DOCKER_HUB_ORG/brisk-queue:latest-dev $DOCKER_HUB_ORG/brisk-queue:$TRAVIS_TAG;
	docker login -u=$DOCKER_HUB_USERNAME -p=$DOCKER_HUB_PASSWORD;
	docker push $DOCKER_HUB_ORG/brisk-queue:$TRAVIS_TAG;
fi