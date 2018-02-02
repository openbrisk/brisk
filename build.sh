#!/bin/sh

if [ ! -s "$TRAVIS_TAG" ] ; then
	echo "This OpenBrisk build will be published as version: ${TRAVIS_TAG}"
fi

docker build --build-arg https_proxy=$https_proxy --build-arg http_proxy=$http_proxy \
  -t openbrisk/brisk-controller:latest-dev . \
  -f controller.Dockerfile --no-cache

docker build --build-arg https_proxy=$https_proxy --build-arg http_proxy=$http_proxy \
  -t openbrisk/brisk-gateway:latest-dev . \
  -f gateway.Dockerfile --no-cache

docker build --build-arg https_proxy=$https_proxy --build-arg http_proxy=$http_proxy \
  -t openbrisk/brisk-queue:latest-dev . \
  -f queue.Dockerfile --no-cache