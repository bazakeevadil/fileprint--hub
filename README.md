# fileprint--hub

RESTful API service designed for convenient browsing of files on a disk drive and providing a list of available printers. Developed on the .Net 7 platform.

File and Printer API<br />
RESTful API для просмотра файлов на дисковом носителе и получения списка принтеров.<br />
Функциональность<br />
Управление документами: получение списка файлов и каталогов, фильтрация, навигация.<br />
Получение файла в Base64 формате.<br />
Операции с принтерами: получение списка принтеров и их статусов.<br />
Технологии<br />
.NET 7<br />
ASP.NET Core Web API<br />
Swagger/OpenAPI для документации<br />
Запуск<br />
Клонировать репозиторий<br />
Выполнить dotnet restore<br />
Запустить dotnet run<br />
Проверить документацию Swagger по адресу http://localhost:7000/swagger<br />
Эндпоинты<br />
GET /api/files - получить встроенную флешку<br />
GET /api/files/{path} - получить файлы по пути<br />
GET /api/files/file - получить файл в Base64<br />
GET /api/printers - получить список принтеров<br />
Автор<br />
[Adil]<br />
Пожалуйста, создайте issue или отправьте pull request если найдете баги!<br />
Этот файл описывает цель проекта, его функциональность, технологии, инструкцию по запуску и <br />использованию API. Дайте знать если требуется что-либо дополнить.<br />
