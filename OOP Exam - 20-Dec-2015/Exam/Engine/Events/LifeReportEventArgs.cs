namespace Exam.Engine.Events
{
	public class LifeReportEventArgs
	{
		public LifeReportEventArgs(string propertyName, bool oldValue, bool newValue)
		{
			this.PropertyName = propertyName;
			this.OldValue = oldValue;
			this.NewValue = newValue;
		}

		public string PropertyName { get; set; }
		public bool OldValue { get; set; }
		public bool NewValue { get; set; }
	}
}