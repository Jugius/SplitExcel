
namespace SplitExcel.Tools
{
    public struct ProgressData
    {
        /// <summary>
        /// Прогресс в процентах (1-100)
        /// </summary>
        public int Progress => TicksDone * 100 / TicksTotal;
        /// <summary>
        /// Количество шагов сделано
        /// </summary>
        public int TicksDone { get; }
        /// <summary>
        /// Количество шагов всего
        /// </summary>
        public int TicksTotal { get; }
        public ProgressData(int ticksDone, int ticksTotal)
        {
            this.TicksDone = ticksDone;
            this.TicksTotal = ticksTotal;
        }
    }
    public class ProgressTicker
    {
        public delegate void ProgressChangedEventHandler(ProgressData data);
        public event ProgressChangedEventHandler ProgressChanged;

        readonly int Length;
        readonly int Step;
        private int Flag = 0;
        private int Updated = 0;
        public int Ticks { get { return Updated; } }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="expectedTicks">Ожидаемое количество шагов</param>
        /// <param name="stepInPersent">Процент выполнения прогресса, при котором происходит событие ProgressChanged</param>
        public ProgressTicker(int expectedTicks, int stepInPersent)
        {
            this.Length = expectedTicks;
            this.Step = stepInPersent * expectedTicks / 100;
        }
        public void Tick()
        {
            this.Updated++;
            this.Flag++;
            if (Flag >= Step || Updated == Length)
            {
                int pers = Updated * 100 / Length;
                if (pers == 0) pers++;
                ProgressChanged?.Invoke(new ProgressData(Updated, Length));
                Flag = 0;
            }
        }
    }
}
