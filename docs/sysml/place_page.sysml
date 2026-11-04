package TourGuide_Place {
    part def PlacePage {
        attribute title = "Немига / Верхний город";
        part header : Header;
        part placeInfo : PlaceInfo;
        part routeBuilder : RouteBuilder;
        part mapRoute : MapRoute;
        part actions : Actions;
        part footer : Footer;
    }

    part def PlaceInfo {
        attribute name = "Название достопримечательности";
        attribute description = "Краткое описание и история";
        attribute rating = "4.7";
        attribute gallery = "Фотогалерея";
        attribute hours = "Режим работы";
    }

    part def RouteBuilder {
        attribute points = "Точки текущего маршрута";
        attribute addButton = "Добавить в маршрут";
        attribute optimize = "Оптимизировать порядок точек";
    }

    part def MapRoute {
        attribute path = "Линия маршрута на карте";
        attribute api = "Leaflet / Yandex Maps";
    }

    part def Actions {
        attribute favorite = "В избранное";
        attribute share = "Поделиться";
        attribute start = "Начать маршрут";
    }

    part def Header {
        attribute logo = "TourGuide";
        attribute back = "Назад к каталогу";
    }

    part def Footer {
        attribute info = "О приложении, Контакты";
    }
}
