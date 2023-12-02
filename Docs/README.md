# 

## [ImageAnalyzerLibrary](/Source/ImageAnalyzeLibrary/)

Является основой для проекта, содержит основные типы и интерфейсы для написания логики.

    ImageAnalyzer:
        представляет собой объект, объединяющий алгоритмы проверки изображения на фальсификацию, предоставляя метод CheckImageForgery.

    IAnalyzeStrategy:
        интерфейс общего вида работы алгоритмов, которые определяют фальсификацию

<div align="center">

![](/Docs/Images/Диаграмма%20классов%20ImageAnalyzerLibrary.png)

__Диаграмма классов__
</div>

## [ImageAnalyzeLibrary.Metadata](/Source/ImageAnalyzeLibrary.Metadata/)

Пример реализации __IAnalyzeStrategy__, работающий на основе проверки метаданных изображения.

    IMetadataAnalyzer:
        представляет интерфейс для проверки метаданных изображения.


<div align="center">

![](/Docs/Images/Диаграмма%20классов%20ImageAnalyzerLibrary.Metadata.png)

__Диаграмма классов__
</div>

## [Пример использования библиотеки](/Source/ImageAnalyzeLibrary.Example/)

Создание ImageAnalyzer через Builder-интерфейс:

    ```csharp
    ImageAnalyzerBuilder.Create()
            .AddMetadataStrategy
            (
                cfg => cfg
                    .AnalyzePhotoshop()
            )
            .Build();
    ```

## [Тестирование](/Source/CreditTask.Tests/)

Для тестирования необходимо выполнить следующие шаги:

1. Склонировать репозиторий

    ```console
    $ git clone https://github.com/RTDElap/CreditTask
    ```

2. Перейти в папку Source

    ```console
    $ cd CreditTask/Source
    ```

3. Скачать зависимости

    ```console
    $ dotnet restore
    ```

4. Указать путь к ассетам через переменную окружения

    ```console
    $env:ASSETS_PATH="../Assets"
    ```

5. Запустить тесты

    ```console
    $ dotnet test
    ```