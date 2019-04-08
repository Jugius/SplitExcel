
namespace SplitExcel.Tools
{
    public struct ProgressData
    {
        /// <summary>
        /// Прогресс в процентах (1-100)
        /// </summary>
        public int Progress { get; }
        /// <summary>
        /// Количество шагов сделано
        /// </summary>
        public int TicksDone { get; }
        /// <summary>
        /// Количество шагов всего
        /// </summary>
        public int TicksTotal { get; }
        public ProgressData(int progress, int ticksDone, int ticksTotal)
        {
            this.Progress = progress;
            this.TicksDone = ticksDone;
            this.TicksTotal = ticksTotal;
        }
    }
    public class ProgressTicker
    {
        public delegate void ProgressChangedEventHandler(ProgressData data);
        public event ProgressChangedEventHandler ProgressChanged;

        int Length;
        int Step;
        int Flag;
        int Updated;
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
            this.Flag = this.Updated = 0;
        }
        public void Tick()
        {
            this.Updated++;
            this.Flag++;
            if (Flag >= Step || Updated == Length)
            {
                int pers = Updated * 100 / Length;
                if (pers == 0) pers++;
                ProgressChanged?.Invoke(new ProgressData(pers, Updated, Length));
                Flag = 0;
            }
        }
    }
}
