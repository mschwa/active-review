﻿function Session(data) {
    var self = this;
    self.name = ko.observable(data.Name);

    //self.Reviewer = ko.observable(reviewer);

    //self.selectItem = function (data) {
    //    homeModel.setReviewer(data);
    //}
}

//View Model
function ViewModel() {
    var self = this;
    //self.selectedItem = null;
    
    //My created sessions List
    //self.myCreatedSessionsList = ko.observableArray([
    //    new Session("Session Title 1"),
    //    new Session("Session Title 2"),
    //    new Session("Session Title 3")
    //]);

    self.myCreatedSessionsList = ko.observableArray([]);

    $.getJSON("http://localhost:55519/api/reviewsession", function (allData) {
        var mappedSessions = $.map(allData, function (item) { return new Session(item) });
        self.myCreatedSessionsList(mappedSessions);
    });

    //My created sessions List
    self.myActiveSessionsListReviewer = ko.observableArray([
        new Session("Session Title 1"),
        new Session("Session Title 2")
    ]);

    //My created sessions List
    self.myActiveSessionsListCreator = ko.observableArray([
        new Session("Session Title 1"),
        new Session("Session Title 2")
    ]);

    //My created sessions List
    self.myArchivedSessionsList = ko.observableArray([
        new Session("Session Title 1")
    ]);

    //Remove Session
    self.removeSession = function(session) 
    {
        self.myCreatedSessionsList.remove(session);
    }

    // Add Reviewer
    //self.currentReviewer = ko.observable("");

    //self.setReviewer = function (selectedSession) {
    //    self.selectedItem = selectedSession;
    //    self.currentReviewer(self.selectedItem.Reviewer());
    //}

    //self.saveReviewer = function () {
    //    self.selectedItem.Reviewer(self.currentReviewer());
    //    self.selectedItem = null;
    //}

}

//var homeModel = new ViewModel();
ko.applyBindings(new ViewModel());