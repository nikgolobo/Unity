---
name: CastleBounty
description: 2D pixel-art action platformer landing page for a dark fantasy indie game
colors:
  void-bg: "#0a0a0f"
  surface: "#13131f"
  surface-glass: "rgba(255,255,255,0.03)"
  text-primary: "#ffffff"
  text-secondary: "#a1a1aa"
  text-tertiary: "#71717a"
  border: "rgba(255,255,255,0.1)"
  border-hover: "rgba(255,255,255,0.2)"
  accent-violet: "#8b5cf6"
  accent-blue: "#3b82f6"
  accent-cyan: "#06b6d4"
  success: "#10b981"
  warning: "#f59e0b"
  error: "#ef4444"
typography:
  display:
    fontFamily: "Inter, system-ui, sans-serif"
    fontSize: "clamp(2.25rem, 5vw, 3.5rem)"
    fontWeight: 800
    lineHeight: 1.1
    letterSpacing: "-0.04em"
  headline:
    fontFamily: "Inter, system-ui, sans-serif"
    fontSize: "clamp(1.75rem, 3vw, 2.625rem)"
    fontWeight: 700
    lineHeight: 1.1
    letterSpacing: "-0.03em"
  title:
    fontFamily: "Inter, system-ui, sans-serif"
    fontSize: "1.25rem"
    fontWeight: 600
    lineHeight: 1.2
    letterSpacing: "-0.015em"
  body:
    fontFamily: "Inter, system-ui, sans-serif"
    fontSize: "1rem"
    fontWeight: 400
    lineHeight: 1.6
    letterSpacing: "0"
  label:
    fontFamily: "Inter, system-ui, sans-serif"
    fontSize: "0.75rem"
    fontWeight: 700
    lineHeight: 1.5
    letterSpacing: "0.05em"
  mono:
    fontFamily: "JetBrains Mono, ui-monospace, monospace"
    fontSize: "0.875rem"
    fontWeight: 500
    lineHeight: 1.5
    letterSpacing: "0"
rounded:
  sm: "8px"
  md: "12px"
  lg: "16px"
  xl: "20px"
  full: "9999px"
spacing:
  xs: "4px"
  sm: "8px"
  md: "16px"
  lg: "24px"
  xl: "32px"
  2xl: "48px"
  3xl: "64px"
  4xl: "96px"
  5xl: "120px"
components:
  button-primary:
    backgroundColor: "linear-gradient(90deg, {colors.accent-violet}, {colors.accent-blue})"
    textColor: "#ffffff"
    rounded: "{rounded.md}"
    padding: "16px 32px"
    typography: "{typography.title}"
  button-primary-hover:
    filter: "brightness(1.1)"
    boxShadow: "0 0 40px rgba(139, 92, 246, 0.4)"
    transform: "translateY(-2px)"
  button-secondary:
    backgroundColor: "{colors.surface-glass}"
    textColor: "{colors.text-primary}"
    rounded: "{rounded.md}"
    padding: "16px 32px"
    border: "1px solid {colors.border}"
  button-secondary-hover:
    backgroundColor: "rgba(255,255,255,0.06)"
    borderColor: "{colors.border-hover}"
    transform: "translateY(-2px)"
  card:
    backgroundColor: "{colors.surface-glass}"
    border: "1px solid {colors.border}"
    rounded: "{rounded.lg}"
    padding: "32px"
    backdropFilter: "blur(10px)"
  card-hover:
    borderColor: "{colors.border-hover}"
    transform: "translateY(-6px) scale(1.02)"
    boxShadow: "0 20px 50px rgba(0,0,0,0.4), 0 0 40px rgba(139,92,246,0.1)"
  nav:
    backgroundColor: "rgba(10,10,15,0.7)"
    border: "1px solid {colors.border}"
    backdropFilter: "blur(20px)"
    padding: "16px 48px"
  hero-image:
    border: "1px solid {colors.border}"
    rounded: "{rounded.xl}"
    boxShadow: "0 32px 80px rgba(0,0,0,0.5), 0 0 60px rgba(139,92,246,0.15)"
---

# Design System: CastleBounty

## 1. Overview

**Creative North Star: "The Cursed Arcade Cabinet"**

CastleBounty's website should feel like a game screen that happens to be a browser page. The interface is dark, atmospheric, and slightly electric — a haunted castle rendered in modern web tech. Pixel art and gameplay screenshots drive the narrative; the UI recedes into a void-black background so the game art glows. Every element carries a hint of violet magic, as if the page itself is cursed.

The design rejects the clean, bright SaaS look of Stripe, Vercel, and Linear. It also avoids generic pastel indie-game clichés. Instead it borrows from the moody, art-led presentation of Itch.io indie darlings: rich darkness, one strong accent, retro-cool energy, and bold type. It is built for teenagers and young indie-game fans who discover games on Itch.io and expect a page that feels like part of the game.

**Key Characteristics:**
- Void-black canvas with a single violet-to-blue gradient accent.
- Glassmorphism cards that float above the background, not boxes in boxes.
- Pixel-art game screenshots and characters are the primary visual content.
- Generous, cinematic spacing — the page breathes like a title screen.
- Subtle glows and motion on interactive elements; never noisy, always purposeful.
- Russian-language ready (UI spacing supports longer labels; icon-forward design).

## 2. Colors

The palette is intentionally small: a deep void background, a warm neutral text ramp, and one gradient accent that shifts between violet magic and cold steel.

### Primary
- **Violet Magic** (`#8b5cf6`): The game's primary accent — buttons, badges, feature icons, stats, and the ambient hero glow. It is the "magic" color of the cursed castle.
- **Cold Steel** (`#3b82f6`): Secondary accent used in the primary gradient and for subtle highlights. Makes the violet feel icy and dangerous.

### Neutral
- **Void Black** (`#0a0a0f`): Page background. The deepest color; makes game screenshots pop.
- **Surface Black** (`#13131f`): Surface for cards, nav, and elevated containers. Slightly lifted from the void.
- **Glass White** (`rgba(255,255,255,0.03)`): Translucent surface for cards and buttons when filled backgrounds would feel too heavy.
- **Primary Text** (`#ffffff`): Headlines, body text, and strong labels on dark surfaces.
- **Secondary Text** (`#a1a1aa`): Descriptions, captions, and de-emphasized copy.
- **Tertiary Text** (`#71717a`): Footer, meta, and the quietest labels.
- **Subtle Border** (`rgba(255,255,255,0.1)`): Default borders for cards, nav, and image frames.
- **Hover Border** (`rgba(255,255,255,0.2)`): Border on hover and focus states.

### Semantic
- **Success** (`#10b981`): Early-access badges, positive status.
- **Warning** (`#f59e0b`): Beta tags, cautionary copy.
- **Error** (`#ef4444`): Game-over, destructive actions.
- **Cyan Spark** (`#06b6d4`): Accent variation for feature icons and data points.

### Named Rules
**The One Glow Rule.** The violet-to-blue gradient appears on primary CTAs and the ambient hero light only. Every other surface stays dark or glass. This preserves the accent's power and prevents the page from becoming a rainbow.

**The Tinted Border Rule.** Borders are white at 10% opacity, never pure gray. On dark surfaces, gray looks muddy; white transparency harmonizes with the palette.

## 3. Typography

**Display & Body Font:** Inter (system-ui fallback)  
**Mono Font:** JetBrains Mono (for code/tech labels)  

**Character:** Inter gives a modern, game-launcher feel without feeling corporate. Headings are bold and slightly compressed; body text is open and readable. The combination is direct and energetic, like a HUD or title screen.

### Hierarchy
- **Display** (800, clamp(2.25rem, 5vw, 3.5rem), line-height 1.1, letter-spacing -0.04em): Hero headline only. One or two lines, maximum impact.
- **Headline** (700, clamp(1.75rem, 3vw, 2.625rem), line-height 1.1, letter-spacing -0.03em): Section headings and final CTA.
- **Title** (600, 1.25rem, line-height 1.2): Feature card headings, showcase titles, button text.
- **Body** (400, 1rem, line-height 1.6): Descriptions, paragraphs, card body copy. Max 65–75ch.
- **Label** (700, 0.75rem, line-height 1.5, letter-spacing 0.05em, uppercase): Badges, tags, category labels.
- **Mono** (500, 0.875rem, line-height 1.5): Tech meta, stats, code snippets.

### Named Rules
**The Tight Display Rule.** Display and headline letter-spacing never goes below -0.04em. Any tighter and letters touch; the headline becomes cramped, not dramatic.

**The White-on-Void Rule.** Body text on dark surfaces is pure white (#ffffff) or very light gray (#a1a1aa), never medium gray. Muted gray on dark backgrounds looks washed out and fails contrast expectations.

## 4. Elevation

The system uses a hybrid of glassmorphism and glow for depth. Surfaces are flat at rest; depth comes from translucent layers, colored borders, and violet glow rather than conventional drop shadows. Buttons and cards gain a lift on hover, but the default state is grounded and dark.

### Shadow / Glow Vocabulary
- **Ambient Hero Glow** (`radial-gradient(ellipse, rgba(139, 92, 246, 0.25) 0%, transparent 70%)`): A large, soft violet light behind the hero headline. Creates the "cursed atmosphere" without a literal image.
- **Image Frame Glow** (`0 0 60px rgba(139, 92, 246, 0.15)`): Subtle violet halo around hero screenshots and video containers.
- **Card Hover Lift** (`0 20px 50px rgba(0,0,0,0.4), 0 0 40px rgba(139,92,246,0.1)`): Depth on hover; the violet glow is visible only on interaction.
- **Button Glow** (`0 0 40px rgba(139, 92, 246, 0.4)`): Primary button hover state.
- **Nav Backdrop** (`rgba(10,10,15,0.7)` with `backdrop-filter: blur(20px)`): Sticky navigation that floats over scrolling content.

### Named Rules
**The Glass, Not Boxes Rule.** Cards and buttons use translucent fills with white-tinted borders. Avoid opaque flat color blocks on the dark background — they feel like pasted-on UI rather than part of the cursed world.

**The Glow Is Earned Rule.** Glow appears only on interactive elements, the hero, and media frames. Static text and empty areas stay dark. This keeps the page readable and prevents visual fatigue.

## 5. Components

### Buttons
- **Shape:** Rounded corners (`12px` radius) — soft but not pill-shaped.
- **Primary:** Gradient background (`violet → blue`), white text, `16px 32px` padding. No border; the gradient is the identity.
- **Hover / Focus:** Brightness +10%, violet glow (`0 0 40px rgba(139, 92, 246, 0.4)`), translate up 2px.
- **Secondary:** Glass background (`rgba(255,255,255,0.03)`), white-tinted border, white text. Same padding and radius as primary.
- **Hover:** Slightly lighter glass (`rgba(255,255,255,0.06)`), brighter border, translate up 2px.

### Cards / Containers
- **Corner Style:** `16px` radius for feature cards, `20px` for character cards and media frames.
- **Background:** Glass white (`rgba(255,255,255,0.03)`).
- **Border:** 1px white at 10% opacity.
- **Shadow Strategy:** No default shadow; hover adds depth + subtle violet glow.
- **Internal Padding:** 32px standard for feature cards; 24px for character info.
- **Backdrop Filter:** `blur(10px)` on most cards for glass effect.

### Feature Cards
- Small icon tile (`48px × 48px`, `12px` radius) sits above the title.
- Icon tile background is a low-opacity tint of the card's accent color (violet, blue, cyan, green, amber, red).
- Title is `1.25rem` semi-bold; body is `1rem` secondary text.
- Hover scales 1.02 and lifts.

### Character Cards
- Large square image area (1:1 aspect ratio) with a subtle gradient background.
- Pixel-art character sprite centered, `object-fit: contain`, `image-rendering: pixelated`.
- Role label in uppercase, `accent-violet`.
- Name is `1.375rem` bold; description is `0.875rem` secondary.
- Hover lifts the entire card.

### Media Frames (Screenshots / Video)
- `16:9` aspect ratio, `20px` to `24px` radius.
- Border: 1px white at 10% opacity.
- Subtle violet ambient glow behind the frame.
- Optional overlay gradient from top/bottom to fade into the void.
- Play button for video: circular gradient button with white triangle icon, centered, 80px diameter.

### Navigation
- Sticky top bar with glass backdrop (`blur(20px)`).
- Background: `rgba(10,10,15,0.7)` with subtle white-tinted border.
- Logo: bold gradient text (`violet → blue`), no underline.
- Links: `14px` medium weight, secondary color; hover to white.
- CTA: primary gradient button, small size (`10px 20px`).
- Mobile: hamburger menu or hidden nav; full-width primary CTA on small screens.

### Badges / Tags
- Background: glass or accent color.
- Border-radius: full pill (`9999px`).
- Text: uppercase, `12px`, bold, letter-spacing 0.5px.
- Status dot for "Early Access": green with pulse animation.

## 6. Do's and Don'ts

### Do:
- **Do** keep the page background void-black (`#0a0a0f`) and let game screenshots be the color.
- **Do** use the violet-to-blue gradient only on primary CTAs and hero accents.
- **Do** use pixel-art sprites at their native scale with `image-rendering: pixelated` so they look crisp, not blurry.
- **Do** use glassmorphism cards with white-tinted borders on dark sections.
- **Do** add subtle glow and lift on hover for interactive elements.
- **Do** respect `prefers-reduced-motion` by making animations non-essential.
- **Do** ensure text on dark backgrounds meets WCAG AA contrast.
- **Do** make CTAs feel like arcade buttons: clear, bold, and rewarding to click.

### Don't:
- **Don't** use clean SaaS templates (Stripe, Vercel, Linear, Superhuman) as the visual direction. The page is a game, not a dev tool.
- **Don't** use pastel or rainbow palettes. The page has one accent family: violet, blue, and cyan sparks.
- **Don't** wrap everything in opaque white or gray cards. Glass on dark is the default.
- **Don't** use generic startup language or overly formal copy. Speak like a game trailer.
- **Don't** let screenshots sit without framing. Every image needs a border and subtle glow to feel intentional.
- **Don't** use thin, low-contrast gray body text on dark backgrounds.
- **Don't** use pill-shaped buttons for primary actions. The system uses rounded rectangles (`12px` radius).
