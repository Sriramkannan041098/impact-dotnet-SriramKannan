import AppRouter from "./Router";
import './index.css';

import {
  Box, Card,  Stack, Modal, Paper, Grid,
  Button,  TextField, Typography, MenuItem, Menu, Drawer, Autocomplete,
  TableBody, TableCell, TableContainer, TableHead, TableRow, Table,
  IconButton, Radio, Tooltip,
  ListItemIcon
} from "@mui/material";

export default function App() {
  return (
    <Grid sx={{height:"100%"}}>
      <AppRouter />
    </Grid>
  );
}
