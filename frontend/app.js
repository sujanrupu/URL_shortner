function App() {
  const [url, setUrl] = React.useState("");
  const [shortUrl, setShortUrl] = React.useState("");

  const handleSubmit = async (e) => {
    e.preventDefault();
    setShortUrl("");

    const response = await fetch("https://localhost:5001/api/url/shorten", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ originalUrl: url })
    });

    if (response.ok) {
      const data = await response.json();
      setShortUrl(data.shortUrl);
    } else {
      alert("Failed to shorten URL");
    }
  };

  return (
    <div>
      <h1 className="text-2xl font-bold mb-4 text-center">🔗 URL Shortener</h1>
      <form onSubmit={handleSubmit} className="flex flex-col gap-4">
        <input
          type="url"
          required
          placeholder="Enter your long URL..."
          value={url}
          onChange={(e) => setUrl(e.target.value)}
          className="border rounded-lg p-2 focus:outline-blue-500"
        />
        <button
          type="submit"
          className="bg-blue-600 text-white rounded-lg p-2 hover:bg-blue-700"
        >
          Shorten
        </button>
      </form>

      {shortUrl && (
        <div className="mt-4 text-center">
          <p className="text-gray-600">Shortened URL:</p>
          <a href={shortUrl} className="text-blue-600 underline">{shortUrl}</a>
        </div>
      )}
    </div>
  );
}

ReactDOM.createRoot(document.getElementById("root")).render(<App />);
