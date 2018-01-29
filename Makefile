.PHONY: build

build:
	docker build -t brisk-controller . -f controller.Dockerfile
	docker build -t brisk-gateway . -f gateway.Dockerfile