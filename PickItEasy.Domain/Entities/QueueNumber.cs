namespace PickItEasy.Domain.Entities
{
    public class QueueNumber
    {
        public required string Value { get; set; }
        public required bool Active { get; set; }

        public static List<QueueNumber> Generate()
        {
            List<QueueNumber> queueNumbers = new List<QueueNumber>();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (int i = 0; i < alphabet.Length; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        QueueNumber item = new QueueNumber { Value = $"{alphabet[i]}{j}{k}", Active = true };
                        queueNumbers.Add(item);
                    }
                }
            }
            return queueNumbers;
        }
    }
}