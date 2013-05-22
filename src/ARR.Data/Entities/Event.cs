﻿using System;
using System.Collections.Generic;

namespace ARR.Data.Entities
{
    public enum EventType
    {
        None,
        ReviewerInvited = 1,
        InviteeRegistered = 2,
        FeedbackProvided = 3,
        FeedbackAcknowleged = 4,
        QuestionnaireCompleted = 5,
        ReviewReleased = 6
    }

    public class Event : IPersistentEntity
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public DateTime Created { get; set; }
        public EventType EventType { get; set; }
        public Dictionary<string,string> Info { get; set; }
        public bool Recevied { get; set; }         
    }
}
