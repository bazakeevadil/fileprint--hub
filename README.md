# fileprint--hub

RESTful API service designed for convenient browsing of files on a disk drive and providing a list of available printers. Developed on the .Net 7 platform.

File and Printer API
RESTful API для просмотра файлов на дисковом носителе и получения списка принтеров.
Функциональность
Управление документами: получение списка файлов и каталогов, фильтрация, навигация.
Получение файла в Base64 формате.
Операции с принтерами: получение списка принтеров и их статусов.
Технологии
.NET 7
ASP.NET Core Web API
Swagger/OpenAPI для документации
Запуск
Клонировать репозиторий
Выполнить dotnet restore
Запустить dotnet run
Проверить документацию Swagger по адресу http://localhost:7000/swagger
Эндпоинты
GET /api/files - получить встроенную флешку
GET /api/files/{path} - получить файлы по пути
GET /api/files/file - получить файл в Base64
GET /api/printers - получить список принтеров
Запуск: dotnet test
Автор
[Adil]
Пожалуйста, создайте issue или отправьте pull request если найдете баги!
Этот файл описывает цель проекта, его функциональность, технологии, инструкцию по запуску и использованию API. Дайте знать если требуется что-либо дополнить.
