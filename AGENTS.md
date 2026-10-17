# Keep it simple

- Prefer the simplest design that works. No abstractions, helpers, options, or layers “for later.”
- Only implement what was explicitly requested. Do not add extras (telemetry, configurability, polish, alternate code paths, speculative error handling).
- If something extra seems necessary, **ask and get confirmation before adding it** to the codebase.
- Prefer deleting or not writing code over clever generality.

# Comments

- Comments are rare and short: explain non-obvious *why*, never restate the code.
- No narrating comments (`// increment i`), banners, or essay-length docs in source.
- Do not add doc comments unless the project already uses them for that symbol kind, and keep those to one line when possible.

# Examples

```csharp
// BAD — unrequested flexibility + noisy comments
/// <summary>Stores dates with optional multi-key strategies.</summary>
public void Remember(string? keyA, string? keyB, DateTime? when = null) { /* ... */ }

// GOOD — only what was asked
public void Remember(string key, DateTime dateCreated) { /* ... */ }
```
