# Тестовое задание

## Оглавление

1. [ImageAnalyzerLibrary](#imageanalyzerlibrary)
1. [ImageAnalyzerLibrary.Metadata](#imageanalyzelibrarymetadata)
3. [Пример использования библиотеки](#пример-использования-библиотеки)
4. [Тестирование](#тестирование)

## [ImageAnalyzerLibrary](/Source/ImageAnalyzeLibrary/)

Является основой для проекта, содержит основные типы и интерфейсы для написания логики.

Описание типов:

    ImageAnalyzer:
        Класс, объединяющий алгоритмы проверки изображения на фальсификацию и отвечающий за проход изображения по цепочке.

    IAnalyzeStrategy:
        Интерфейс общего вида работы алгоритмов, которые определяют фальсификацию

<div align="center">

![](/Docs/Images/Диаграмма%20классов%20ImageAnalyzerLibrary.png)

__Диаграмма классов__
</div>

## [ImageAnalyzeLibrary.Metadata](/Source/ImageAnalyzeLibrary.Metadata/)

Пример реализации __IAnalyzeStrategy__, работающий на основе проверки метаданных изображения.

    IMetadataAnalyzer:
        Интерфейс для проверки метаданных изображения.

    PhotoshopAnalyzer:
        Класс, который использует XMP-данные изображения для поиска специфичных значений свойств, оставляемых Photoshop'ом.

<div align="center">

![](/Docs/Images/Диаграмма%20классов%20ImageAnalyzerLibrary.Metadata.png)

__Диаграмма классов__
</div>

## [Пример использования библиотеки](/Source/ImageAnalyzeLibrary.Example/)

Для использования необходимо создать объект, имплементирующий IImageAnalyzer и добавить в него алгоритмы проверки фальсификации.

Пример через Builder:

```csharp
using ImageAnalyzeLibrary.Builders;
using ImageAnalyzeLibrary.Interfaces;
using ImageAnalyzeLibrary.Metadata;

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
    $env:ASSETS_PATH="*полный путь к ассетам*"
    ```

5. Запустить тесты

    ```console
    $ dotnet test
    ```
