import React from 'react';

const HomePage = () => {
  return (
    <div className="home-page">
      <header>
        <h1>iHelpU</h1>
        <nav>
          <a href="#about">About</a>
          <a href="#services">Services</a>
          <a href="#professionals">Find Professionals</a>
          <a href="#signup">Sign Up</a>
        </nav>
      </header>

      <main>
        <section className="hero">
          <h2>Connect with Qualified Professionals</h2>
          <p>Find the right expert for your needs, quickly and easily</p>
          <button className="cta-button">Get Started</button>
        </section>

        <section id="about" className="features">
          <div className="feature">

            <h3>Easy Search</h3>
            <p>Find professionals in various fields with our advanced search system</p>
          </div>
          <div className="feature">
            <h3>Mutual Evaluations</h3>
            <p>Read and leave reviews to ensure quality service</p>
          </div>
          <div className="feature">

            <h3>Quick Connections</h3>
            <p>Connect with professionals instantly and get your job done</p>
          </div>
        </section>

        <section id="services" className="popular-services">
          <h2>Popular Services</h2>
          <div className="service-grid">

          </div>
        </section>

        <section id="professionals" className="featured-pros">
          <h2>Featured Professionals</h2>
          <div className="pro-grid">

          </div>
        </section>
      </main>

      <footer>
        <p>&copy; 2023 iHelpU. All rights reserved.</p>
      </footer>
    </div>
  );
};

export default HomePage;