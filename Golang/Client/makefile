BINARY_NAME=client
DIST_FOLDER="../../dist/go"

build:
	export GOBIN=${HOME}/go/bin
	export GOMODCACHE=${GOPATH}/pkg/mod

	#go get google.golang.org/grpc
	protoc --proto_path=../../proto --go-grpc_out=. --go_out=. greeter.proto
	GOARCH=amd64 GOOS=darwin go build -o ${DIST_FOLDER}/${BINARY_NAME}-darwin main.go
	GOARCH=amd64 GOOS=linux go build -o  ${DIST_FOLDER}/${BINARY_NAME}-linux main.go
	GOARCH=amd64 GOOS=windows go build -o  ${DIST_FOLDER}/${BINARY_NAME}-windows main.go

run:
	./${BINARY_NAME}

build_and_run: build run

clean:
	go clean
	rm -rf ${DIST_FOLDER}