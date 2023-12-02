# Тестовое задание

## Оглавление

1. [Постановка задачи](#постановка-задачи)
3. [Алгоритмы решения задачи](#алгоритмы-решения-задачи)
3. [Решение задачи](#решение-задачи)

## Постановка задачи

Необходимо привести алгоритмы определения фальсификации изображений и предоставить C#-код, имплементирующий проверку.

## Алгоритмы решения задачи

Наиболее известные способы решения задачи включат в себя следующие алгоритмы:

| Название | Описание | Достоинства | Недостатки |
| -------- | -------- | ----------- | ---------- |
| Анализ метаданных | Самый простой из алгоритмов, базирующийся на проверке метаинформации из изображения | Скорость работы | Большинство редакторов не оставляют метаданные инструмента, также их можно удалить |
| Обнаружение Copy-Move | Данный вид алгоритмов направлен на поиск похожих фрагментов изображения (например, используя [SIFT](https://docs.opencv.org/4.x/da/df5/tutorial_py_sift_intro.html) или [БГК](https://cyberleninka.ru/article/n/algoritm-obnaruzheniya-iskazhyonnyh-dublikatov-na-tsifrovyh-izobrazheniyah-s-ispolzovaniem-binarnyh-gradientnyh-konturov/viewer)), либо точного совпадения (например, используя [хэш-таблицу](https://cyberleninka.ru/article/n/poisk-dublikatov-na-tsifrovyh-izobrazheniyah/viewer)) | Независимость от формата изображения | Точность и производительность зависят от используемого алгоритма, также возможны ложные срабатывания |
| Error Level Analysis | Базируется на особенности сжатия с потерями формата JPEG, при котором вставка части из одного изображения в другое образует паттерн скопированной фигуры ([пример](https://www.digitalforensics.com/blog/articles/error-level-analysis/)) | Позволяет увидеть «склейку» изображений | Работает только для формата JPEG, успешность зависит от техники модификации |

_Это не все существующие методы проверки, но наиболее подходящие для проверки на компьютерах в полуавтоматическом режиме_

## Решение задачи

Поскольку все алгоритмы разные, то имеет смысл использовать один общий интерфейс, который будет содержать метод проверки изображения на фальсификацию - _IAnalyzeStrategy_.

Поскольку нет общего алгоритма, который однозначно бы определил фальсификацию изображения, то имеет смысл использовать их все, выстраивая алгоритмы в цепочку алгоритмов для обработки изображения используя паттерн _Chain of responsibility_ - за это ответственен класс _ImageAnalyzer_.

Диаграммы классов, описание интерфейсов и классов, тестирования можно прочитать [тут](/Docs/)