.PHONY: build controller gateway queue

build: controller gateway queue

controller:
	docker build -t openbrisk/brisk-controller . -f controller.Dockerfile

gateway:
	docker build -t openbrisk/brisk-gateway . -f gateway.Dockerfile

queue:
	docker build -t openbrisk/brisk-queue . -f queue.Dockerfile