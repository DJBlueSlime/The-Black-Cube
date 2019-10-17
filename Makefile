test: SHELL:=/bin/bash
test:
	bash <(curl -fsSL https://raw.githubusercontent.com/neogeek/unity-ci-tools/master/bin/test.sh)

clean:
	git clean -xdf
