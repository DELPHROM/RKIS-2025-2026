namespace TodoList;

public class TodoList
{
	const int indexSize = 8;
	const int textSize = 34;
	const int statusSize = 14;
	const int dateSize = 18;

	TodoItem[] items = new TodoItem[2];
	private int taskCount;

	public void Add(TodoItem item)
	{
		if (taskCount == items.Length)
			IncreaseArray();

		items[taskCount] = item;
		taskCount++;
		Console.WriteLine($"��������� ������: {taskCount}) {item.Text}");
	}

	public void Delete(int idx)
	{
		for (var i = idx; i < taskCount - 1; i++)
		{
			items[i] = items[i + 1];
		}

		taskCount--;
		Console.WriteLine($"������ {idx + 1} �������.");
	}

	public void MarkDone(int idx)
	{
		items[idx].MarkDone();
		Console.WriteLine($"������ {items[idx].Text} �������� �����������");
	}

	public void Update(int idx, string newText)
	{
		items[idx].UpdateText(newText);
		Console.WriteLine("������ ���������");
	}

	public void Read(int idx)
	{
		Console.WriteLine(items[idx].GetFullInfo(idx));
	}

	public void View(bool hasIndex, bool hasStatus, bool hasDate, bool hasAll)
	{
		List<string> headers = new List<string>();
		if (hasIndex || hasAll) headers.Add("������".PadRight(indexSize));
		headers.Add("������".PadRight(textSize));
		if (hasStatus || hasAll) headers.Add("������".PadRight(statusSize));
		if (hasDate || hasAll) headers.Add("��������".PadRight(dateSize));

		string header = string.Join(" | ", headers);
		Console.WriteLine(header);
		Console.WriteLine(new string('-', header.Length));

		for (int i = 0; i < taskCount; i++)
		{
			string title = items[i].Text.Replace("\n", " ");
			if (title.Length > 30) title = title.Substring(0, 30) + "...";

			List<string> rows = new List<string>();
			if (hasIndex || hasAll) rows.Add((i + 1).ToString().PadRight(indexSize));
			rows.Add(title.PadRight(textSize));
			if (hasStatus || hasAll) rows.Add((items[i].IsDone ? "���������" : "�� ���������").PadRight(statusSize));
			if (hasDate || hasAll) rows.Add(items[i].LastUpdate.ToString("yyyy-MM-dd HH:mm").PadRight(dateSize));

			Console.WriteLine(string.Join(" | ", rows));
		}
	}

	private void IncreaseArray()
	{
		var newSize = items.Length * 2;
		Array.Resize(ref items, newSize);
	}
}