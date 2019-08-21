'use strict';

var fs = require('fs');
var http = require('http');
var formdata = require('formidable');

function onRequest(request, response) {

    request.files = {};
    request.data = {};

    var form = new formdata.IncomingForm();
    form.uploadDir = "D:/Package";//指定保存文件的路径，formidable会自动保存文件
    form.on('field', function (name, value) {
        request.data[name] = value;//这里提取的是键值对数据
    }).on('file', function (name, file) {
        request.files[name] = file;//这里提取上传的文件
    }).on('end', function () {

        request.startTime = new Date();

        //默认保存的文件名是随机串，需要自己重新指定文件名和后缀
        for (var k in request.files) {
            var f = request.files[k];
            var n = f.name;
            fs.renameSync(f.path, form.uploadDir + "/" + n);

            response.writeHead(200, { 'Content-type': 'text/html' });
            response.write("{ \"code\": 0 }");
        }

        // 用户登录
        for (var k in request.data) {
            var f = request.data[k];
            var data = JSON.stringify({ code: 0 });
            
            response.writeHead(200, { 'Content-type': 'text/html' });
            response.write(data);
        }
        response.end();
    });
    form.parse(request);
}

//启动服务
http.createServer(onRequest).listen(8081);
