namespace Exam.Engine.Events
{
	public class BehaviorReportEventArgs
	{
		public BehaviorReportEventArgs(string propertyName, bool oldValue, bool newValue)
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
