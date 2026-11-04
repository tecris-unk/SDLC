package TourGuide_Dashboard {
    part def DashboardPage {
        attribute title = "TourGuide – Интересные места";
        part header : Header;
        part filterPanel : FilterPanel;
        part placeList : PlaceList;
        part mapWidget : MapWidget;
        part footer : Footer;
    }

    part def Header {
        attribute logo = "TourGuide";
        attribute search = "Поиск мест";
    }

    part def FilterPanel {
        attribute categories = "Музеи, Парки, Архитектура, Еда";
        attribute rating = "Рейтинг от";
        attribute duration = "Длительность посещения";
    }

    part def PlaceList {
        attribute items = "Список карточек достопримечательностей";
    }

    part def MapWidget {
        attribute provider = "OpenStreetMap / Leaflet";
        attribute markers = "Маркеры выбранных и найденных мест";
    }

    part def Footer {
        attribute info = "О приложении, Контакты";
    }
}
