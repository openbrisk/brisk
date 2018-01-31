.PHONY: build controller gateway

build: controller gateway

controller:
	docker build -t openbrisk/brisk-controller . -f controller.Dockerfile

gateway:
	docker build -t openbrisk/brisk-gateway . -f gateway.Dockerfile