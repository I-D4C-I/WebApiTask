# С# WebApi Task
# Тестовое задание на ASP.NET Core (.NET 6):

Реализовать веб-службу REST API. Использовать БД + EntityFramework Есть несколько сущностей:

1. Блок обуривания (DrillBlock), поля: Id, Name, UpdateDate
2. Скважина (Hole), поля: Id, Name, DrillBlockId, DEPTH
3. Точки блока (DrillBlockPoints), соединяются последовательно, являются географическим контуром блока обуривания. Поля: Id, DrillBlockId, Sequence, X, Y, Z
4. Точки скважин (HolePoints) - координаты скважин. Поля: Id, HoleId, X, Y, Z

Реализуйте CRUD для перечисленных сущностей. Данные передаются в формате JSON. 

В базе данных уже должны содержаться объекты. 

Проверка работоспособности API осуществляется с помощью **HTTP-файла** или **Swagger UI**.

# Пример работы

<p align="center">
  <img src="https://github.com/I-D4C-I/WebApiTask/assets/98944264/7875fc3f-dc08-4fe7-b82d-798c791f2093" />
  <br>
  <img src="https://github.com/I-D4C-I/WebApiTask/assets/98944264/8d0cc2bc-68c1-4837-ba14-83e8f2024019" />
  <br>
  <img src="https://github.com/I-D4C-I/WebApiTask/assets/98944264/52379173-7bf8-44a4-9f04-47b35ae2c717" />
    <br>
  <img src="https://github.com/I-D4C-I/WebApiTask/assets/98944264/1df94d39-c0e2-46d8-8e76-dc31311e486c" />
    <br>
  <img src="https://github.com/I-D4C-I/WebApiTask/assets/98944264/b9dc87cd-adfb-47b4-9aa8-78b2f6484416" />
    <br>
  <img src="https://github.com/I-D4C-I/WebApiTask/assets/98944264/6d380368-4f8c-4cdf-97f9-adf34ee450fc" />
</p>
