# Конфигурация компьютера: 
ОС: Windows 10
Язык серверной части: C#
Фронт: React
База данных: MS SQL Server

# Задача
Разработать веб-сайт для просмотра, добавления, редактирования и удаления информации по моделям автомобилей, а также базу данных к нему. 
У сущности «Автомобиль» должны быть следующие поля:
Уникальный идентификатор, обязательное поле.
Бренд - справочник, обязательное поле. По умолчанию в базе данных следующие значения: Audi, Ford, Jeep, Nissan, Toyota.
Название модели - строка, длинной до 1000 символов, обязательное поле.
Дата и время создания записи в БД – обязательное поле. При создании должно прописываться текущее время. При редактировании не должно изменяться. 
Тип кузова - справочник, обязательное поле. По умолчанию в базе данных следующие значения: Седан, Хэтчбек, Универсал, Минивэн, Внедорожник, Купе.
SeatsCount – число сидений в салоне, обязательное поле, должно быть от 1 до 12.
Url сайта официального дилера - строка, длина до 1000 символов, необязательное поле. Сайт должен быть в домене «.ru». 
На сайте можно просмотреть список моделей автомобилей. Для каждого из элементов списка выводится название модели, название бренда, название типа кузова, количество мест и кнопки «Редактировать» и «Удалить». Список выводится по 10 элементов, есть постраничная навигация. По нажатию на «Редактировать» пользователь может отредактировать все поля «Автомобиля». По нажатию на «Удалить» запись об «Автомобиле» должна быть удалена из БД. На странице списка должна быть также кнопка «Добавить», по нажатию на которую пользователь может внести данные для создания новой записи об «Автомобиле» в БД. Добавление и редактирование информации об «Автомобиле» должно идти с валидацией введённых значений. Если значение одного или нескольких полей не проходит валидацию, то информация должна быть выведена пользователю. Информация об успешном добавлении, редактировании или удалении должна быть выведена пользователю. 
База данных должна создаваться при первом обращении к сайту, либо с помощью запуска отдельного приложения. 

