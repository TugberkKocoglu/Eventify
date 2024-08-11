using Eventify.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventify.Application.Abstractions.Services.Concrete
{
    public class ExportService
    {
        private readonly ITextService _textService;
        private readonly IFileService _fileService;

        public ExportService(IFileService fileService, ITextService textService)
        {
            _fileService = fileService;
            _textService = textService;
        }

        public async Task ExportEventAsync(IEnumerable<EventDTO> evenItems, string path)
        {
            var formattedText = _textService.FormatTextForEvent(evenItems);
            await _fileService.SaveTextAsync(formattedText, path);
        }
    }
}
