#! /bin/bash

if [ -z $1 ] ; then
    echo 'Please provide a valid docker tag';
    exit 1;
fi

docker build -t lowxorx/swtoroptimizer:$1 -t lowxorx/swtoroptimizer -f Dockerfile.Optimizer .
docker build -t lowxorx/swtorcalculator:$1 -t lowxorx/swtorcalculator -f Dockerfile.Calculator .

docker push lowxorx/swtoroptimizer:$1
docker push lowxorx/swtorcalculator:$1

docker push lowxorx/swtoroptimizer:latest
docker push lowxorx/swtorcalculator:latest