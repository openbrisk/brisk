if [ ! -s "$TRAVIS_TAG" ] ; then 
	docker tag $DOCKER_HUB_ORG/brisk-controller:latest-dev $DOCKER_HUB_ORG/brisk-controller:$TRAVIS_TAG;
	docker login -u=$DOCKER_HUB_USERNAME -p=$DOCKER_HUB_PASSWORD;
	docker push $DOCKER_HUB_ORG/gateway:$TRAVIS_TAG;
fi