'use strict';

var fs = require('fs');
var http = require('http');
var formdata = require('formidable');

function onRequest(request, response) {

    request.files = {};
    request.data = {};

    var form = new formdata.IncomingForm();
    form.uploadDir = "D:/Package";//ָ�������ļ���·����formidable���Զ������ļ�
    form.on('field', function (name, value) {
        request.data[name] = value;//������ȡ���Ǽ�ֵ������
    }).on('file', function (name, file) {
        request.files[name] = file;//������ȡ�ϴ����ļ�
    }).on('end', function () {

        request.startTime = new Date();

        //Ĭ�ϱ�����ļ��������������Ҫ�Լ�����ָ���ļ����ͺ�׺
        for (var k in request.files) {
            var f = request.files[k];
            var n = f.name;
            fs.renameSync(f.path, form.uploadDir + "/" + n);

            response.writeHead(200, { 'Content-type': 'text/html' });
            response.write("{ \"code\": 0 }");
        }

        // �û���¼
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

//��������
http.createServer(onRequest).listen(8081);
