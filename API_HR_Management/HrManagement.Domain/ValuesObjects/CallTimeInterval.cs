
namespace HrManagement.Domain.ValuesObjects
{
    public record CallTimeInterval
    {
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        // Factory method to handle creation and encapsulate validation
        public static CallTimeInterval Of(CallTimeInterval callTimeInterval)
        {
            if (callTimeInterval?.EndTime <= callTimeInterval?.StartTime)
            {
                throw new ArgumentException("End time must be after start time.");
            }

            return new CallTimeInterval
            {
                StartTime = callTimeInterval?.StartTime,
                EndTime = callTimeInterval?.EndTime
            };

        }



    }
}
