﻿namespace JoF.Rail.Standard.Models.LiveDepartureBoard.Result
{
    using System.Collections.Generic;

    public class FormationModel
    {
        public string AverageLoading { get; set; }

        public IEnumerable<CoachModel> Coaches { get; set; }
    }
}
