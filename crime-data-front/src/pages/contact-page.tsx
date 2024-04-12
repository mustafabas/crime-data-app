import React from 'react';
import { Container, Link, Typography } from '@mui/material';

const HomePage: React.FC = () => {
  return (
    <Container>
      <Typography variant="h4" gutterBottom>
        Contact Me
      </Typography>
      <Typography variant="body1">
        For inquiries or support, please contact me at hi@fillsoftware.com.
      </Typography>
      <Typography variant="body1">
        <Link href="/">Go Back to Homepage</Link>
      </Typography>
    </Container>
  );
};

export default HomePage;