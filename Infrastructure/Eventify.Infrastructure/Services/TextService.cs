using Eventify.Application.Abstractions.Services;
using Eventify.Application.DTOs;
using System.Text;

namespace Eventify.Infrastructure.Services
{
    public class TextService : ITextService
    {
        public string FormatTextForEvent(IEnumerable<EventDTO> eventItems)
        {
            if (eventItems is null)
            {
                throw new ArgumentNullException(nameof(eventItems));
            }

            StringBuilder stringBuilder = new();    //Ekleme işlemlerinde StringBuilder daha performanslı çalıştığından yoksa sttring kullanıcaktık

            foreach (var eventItem in eventItems)
            {
                if (eventItem is not null)
                {
                    stringBuilder.AppendLine($"Event: {eventItem.Title} - Location: {eventItem.Location.City} - Date: {eventItem.Date.ToString("HH:mm - dd/MM/yyyy")}");
                }
                
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
