import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import HomePage from './pages/home-page';
import ContactPage from './pages/contact-page';
import ResponsiveAppBar from './components/nav-bar';

const App: React.FC = () => {
  return (
    <Router>
      <div>
        <ResponsiveAppBar />
        <Routes>
          <Route path="/" Component={HomePage} />
          <Route path="/contact" Component={ContactPage} />
        </Routes>
      </div>
    </Router>
  );
};

export default App;