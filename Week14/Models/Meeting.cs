using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Week14.Models
{
    public class Meeting
    {
        public int ID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public Bishopric Conducting { get; set; }
        public int ConductingID { get; set; }
        [Display(Name = "Opening Hymn")]
        public Hymn OpeningHymn { get; set; }
        public int OpeningHymnID { get; set; }
        [Display(Name = "Sacrament Hymn")]
        public Hymn SacramentHymn { get; set; }
        public int SacramentHymnID { get; set; }
        [Display(Name = "Intermediate Hymn")]
        public Hymn InterHymn { get; set; }
        public int InterHymnID { get; set; }
        [Display(Name = "Closing Hymn")]
        public Hymn ClosingHymn { get; set; }
        public int ClosingHymnID { get; set; }
        public Member Invocation { get; set; }
        public int InvocationID { get; set; }
        public Member Benediction { get; set; }
        public int BenedictionID { get; set; }
        public bool IsFastSunday { get; set; }
        [Display(Name = "First Topic")]
        public string FirstTopic { get; set; }
        [Display(Name = "Second Topic")]
        public string SecondTopic { get; set; }
        [Display(Name = "Third Topic")]
        public string ThirdTopic { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
        [Display(Name = "Second Speaker")]
        public Member MiddleSpeaker { get; set; }
        public int MiddleSpeakerID { get; set; }
        [Display(Name = "Third Speaker")]
        public Member LastSpeaker { get; set; }
        public int LastSpeakerID { get; set; }
        [Display(Name = "First Speaker")]
        public Member FirstSpeaker { get; set; }
        public int FirstSpeakerID { get; set; }
    }
}
