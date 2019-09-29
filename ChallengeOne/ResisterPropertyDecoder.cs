using System;
using System.Text;

namespace ChallengeOne
{
    public class ResisterPropertyDecoder: ICalculateOhmValues
    {
        //This method is not sufficient for calculating ohms for all resisters. Extreme example: If the resister is White White White Silver, there will be an arithmatic overflow (Larger than 32-bit integer). It is advised to make this a long int (64-bit).
        public int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            var primaryBand = ResisterBand.Parse(bandAColor);
            var secondaryBand = ResisterBand.Parse(bandBColor);
            var multiplierBand = ResisterBand.Parse(bandCColor);
            var toleranceBand = ResisterBand.Parse(bandDColor);

            if (primaryBand == null || secondaryBand == null || multiplierBand == null || toleranceBand == null) throw new Exception("One or more of your resister bands are not spelled correctly or were not supplied.");


            var validationErrorMessageBuilder = new StringBuilder();
            if(primaryBand.SignificantDigit == null || secondaryBand.SignificantDigit == null)
            {
                if(primaryBand.SignificantDigit == null) validationErrorMessageBuilder.AppendLine($"{bandAColor} does not designate a digit for resistance. ");
                if (secondaryBand.SignificantDigit == null) validationErrorMessageBuilder.Append($"{bandBColor} does not designate a digit for resistance. ");
                validationErrorMessageBuilder.AppendLine("Please check that you are not reading your resister backwards.");
            }
            if(multiplierBand.Multiplier == null)
            {
                validationErrorMessageBuilder.AppendLine($"{bandCColor} does not designate a resistance multiplier.");
            }
            if(toleranceBand.TolerancePercent == null)
            {
                validationErrorMessageBuilder.AppendLine($"{bandDColor} does not designate a tolerance variant");
            }

            var validationErrorMessage = validationErrorMessageBuilder.ToString().Trim();
            if (validationErrorMessage.Length > 0) throw new Exception(validationErrorMessage);

            return Convert.ToInt32(Math.Floor((10 * primaryBand.SignificantDigit.Value + secondaryBand.SignificantDigit.Value) * multiplierBand.Multiplier.Value *(1+toleranceBand.TolerancePercent.Value/100)));
        }
    }
}
