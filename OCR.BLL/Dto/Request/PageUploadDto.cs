using System;
using System.Collections.Generic;
using System.Text;

namespace OCR.BLL.Dto.Request
{
    public class PageUploadDto
    {
        public int PageNumber { get; set; }

        public string FullText { get; set; }
        
        public DateTime IssuDate { get; set; }

        public int IssueNumber { get; set; }

        public string Image { get; set; }
     }
}
