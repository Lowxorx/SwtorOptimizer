Param(
    [Parameter(Mandatory = $True)][string]$Tag
)

docker build -t lowxorx/swtoroptimizer:$Tag -t lowxorx/swtoroptimizer -f .\Dockerfile.Optimizer .
docker build -t lowxorx/swtorcalculator:$Tag -t lowxorx/swtorcalculator -f .\Dockerfile.Calculator .

docker push lowxorx/swtoroptimizer:$Tag
docker push lowxorx/swtorcalculator:$Tag

docker push lowxorx/swtoroptimizer:latest
docker push lowxorx/swtorcalculator:latest