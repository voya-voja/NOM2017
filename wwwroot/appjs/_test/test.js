var testApp = angular.module("TestApp", []);

testApp.controller('clockCtrl', function ($scope, $interval) {
    $scope.theTime = new Date().toLocaleTimeString();
    $interval(function () {
        $scope.theTime = new Date().toLocaleTimeString();
    }, 1000);
});

testApp.controller('initCtrl', function ($scope, $http) {
    // GET ping TestService
    $http.get('http://localhost:52099/TestService.svc/Ping')
        .then(
        function (response) {
            $scope.pingResp = response.data;
        },
        function (response) {
            $scope.pingResp = response.status + ": " + response.statusText;
        }
        );

    // Initialize testBtnOnClick function
    $scope.testBtnOnClick = function () {
        // the argument name has to be the same as in ITestService.DoWork(TestRequest request) declaraton
        $http.post('http://localhost:52099/TestService.svc/DoWork', { "request": $scope.testRequest })
            .then(
            function (response) {
                $scope.testDataSetHeader = "Test Data Set";
                $scope.testDataSet = response.data.DoWorkResult;
            },
            function (response) {
                $scope.pingResp = response.status + ": " + response.statusText;
            }
            );
    }
});