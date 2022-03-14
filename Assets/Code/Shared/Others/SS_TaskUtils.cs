using System.Threading;

public static class SS_TaskUtils
{
	public static CancellationToken RefreshToken(ref CancellationTokenSource tokenSource)
	{
		tokenSource?.Cancel();
		tokenSource?.Dispose();
		tokenSource = new CancellationTokenSource();
		return tokenSource.Token;
	}

	public static void CancelToken(ref CancellationTokenSource tokenSource)
	{
		if (tokenSource != null && !tokenSource.IsCancellationRequested)
		{
			tokenSource?.Cancel();
		}

		tokenSource?.Dispose();
		tokenSource = null;
	}
}