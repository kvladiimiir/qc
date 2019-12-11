const mbHelper = require('./mountebank-helper');
const settings = require('./settings');
function addService() {
    const response = { message: "hello world" }
    const stubs = [
        {
            predicates: [{
                equals: {
                    method: "GET",
                    "path": "/helloWorld"
                }
            }],
            responses: [
                {
                    is: {
                        statusCode: 200,
                        headers: {
                            "Content-Type": "application/json"
                        },
                        body: "HelloWorld"
                    }
                },
                
            ]
        },
        {
            predicates: [{
                equals: {
                    method: "GET",
                    "path": "/gameGame"
                }
            }],
            responses: [
                {
                    is: {
                        statusCode: 200,
                        headers: {
                            "Content-Type": "application/json"
                        },
                        body: "gameGame"
                    }
                },
                
            ]
        },
        {
            predicates: [{
                equals: {
                    method: "GET",
                    "path": "/customer"
                }
            }],
            responses: [
                {
                    is: {
                        statusCode: 200,
                        headers: {
                            "Content-Type": "application/json"
                        },
                        body: "customerGame"
                    }
                },
                
            ]
        }
    ];
    const imposter = {
        port: settings.hello_service_port,
        protocol: 'http',
        stubs: stubs
    };
    return mbHelper.postImposter(imposter);
}
module.exports = { addService };