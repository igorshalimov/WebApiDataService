# WebApiDataService
Data Service(Сервис Данных)

Данный Сервис можно запустить в Visual Studio, выбрав файл WebApiDataService.csproj, ПКМ контекстное меню: View => View in View in Browser

Далее в браузере:

localhost:44339/api/data => выдает данные(значения на пересечении справочников) на основе запроса, в качестве параметра -  первый объект строительства

localhost:44339/api/data/object=ObjectId => выдает данные на основе запроса, в качестве параметра -  объект строительства, указаный по индексу ObjectId={1,2,3}

localhost:44339/api/data/version=VersionId => выдает данные на основе запроса, в качестве параметра -  версия данных, указаная по индексу VersionId={1,2,3}

