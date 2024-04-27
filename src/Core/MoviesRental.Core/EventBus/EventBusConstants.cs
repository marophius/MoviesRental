using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Core.EventBus
{
    public static class EventBusConstants
    {
        public const string CREATE_DVD_QUEUE = "create-dvd-queue";
        public const string UPDATE_DVD_QUEUE = "update-dvd-queue";
        public const string DELETE_DVD_QUEUE = "delete-dvd-queue";
        public const string RENT_DVD_QUEUE = "rent-dvd-queue";
        public const string RETURN_DVD_QUEUE = "return-dvd-queue";
        public const string CREATE_DIRECTOR_QUEUE = "create-director-queue";
        public const string UPDATE_DIRECTOR_QUEUE = "update-director-queue";
        public const string DELETE_DIRECTOR_QUEUE = "delete-director-queue";
    }
}
